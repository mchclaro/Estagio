using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Result;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Utils;
using MediatR;

namespace Application.Aggregates.Client.Commands
{
    public class CreateClient
    {
        public class Command : IRequest<StandardResult<object>>
        {
            public string Name { get; set; }
            public string Phone { get; set; }
            public IFormFile PhotoUrl { get; set; }
            public string Zipcode { get; set; }
            public string AddressStreet { get; set; }
            public string AddressStreetNumber { get; set; }
            public string AddressDistrict { get; set; }
            public string AddressState { get; set; }
            public string AddressComplement { get; set; }
            public string AddressCity { get; set; }
        }
        public class Handler : IRequestHandler<Command, StandardResult<object>>
        {
            private readonly IClientRepository _clientRepository;
            private readonly IAddressRepository _addressRepository;
            private readonly IFileStorageService _fileStorage;
            private readonly IConfiguration _configuration;
            private readonly IMapper _mapper;
            private readonly string _imageBucket;

            public Handler(IClientRepository clientRepository,
                           IAddressRepository addressRepository,
                           IConfiguration configuration,
                           IMapper mapper, IFileStorageService fileStorage)
            {
                _clientRepository = clientRepository;
                _addressRepository = addressRepository;
                _configuration = configuration;
                _mapper = mapper;
                _fileStorage = fileStorage;
                _imageBucket = "adp-images";
            }
            public async Task<StandardResult<object>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = new StandardResult<object> { };

                try
                {
                    if (request.Phone == null)
                    {
                        result.AddError(Code.BadRequest, "Não foi possível continuar o cadastro pois o celular é são inválidos.");
                        return result.GetResult();
                    }

                    if (await _clientRepository.IsPhoneInUse(request.Phone))
                    {
                        result.AddError(Code.BadRequest, "Já existe uma conta associada ao celular informado.");
                        return result.GetResult();
                    }
                    if (string.IsNullOrEmpty(request.Name))
                    {
                        result.AddError(Code.BadRequest, "O nome do cliente não pode ser vazio.");
                        return result.GetResult();
                    }

                    (bool fileSizeExceeded, string photoUrl) = await updateClientPhotoUrl(request);

                    if (fileSizeExceeded)
                    {
                        result.AddError(Code.BadRequest, photoUrl);
                        return result.GetResult();
                    }

                    var entity = _mapper.Map<Command, Domain.Entities.Client>(request);

                    if (!string.IsNullOrEmpty(photoUrl))
                    entity.PhotoUrl = photoUrl;

                    entity.AddressId = await saveAddress(request);

                    await _clientRepository.Create(entity);

                }
                catch (Exception)
                {
                    result.AddError(Code.GenericError, "Erro ao cadastrar cliente");
                }

                return result.GetResult();
            }
            private async Task<int> saveAddress(Command request)
            {
                var address = new Address
                {
                    Street = request.AddressStreet,
                    StreetNumber = request.AddressStreetNumber,
                    Complement = request.AddressComplement,
                    District = request.AddressDistrict,
                    ZipCode = ValidationHelper.RemoveDirtCharsForCep(request.Zipcode),
                    State = request.AddressState,
                    City = request.AddressCity
                };

                return await _addressRepository.Create(address);
            }

            private async Task<(bool, string)> updateClientPhotoUrl(Command request)
            {
                string photoUrl = string.Empty;
                bool fileSizeExceeded = false;

                if (request.PhotoUrl is null)
                    return (fileSizeExceeded, photoUrl);

                if (!FileSizeValidationHelper.IsFileSizeAllowed(_configuration, request.PhotoUrl.Length))
                {
                    fileSizeExceeded = true;
                    photoUrl = "O tamanho da foto excede o limite permitido. Selecione uma foto que possua no máximo 8MB de tamanho.";

                    return (fileSizeExceeded, photoUrl);
                }

                string photoUuid = Guid.NewGuid().ToString("N");
                string objectName = $"client_photo_{photoUuid}{Path.GetExtension(request.PhotoUrl.FileName)}";
                await _fileStorage.UploadFileFromHttpIFormFile(request.PhotoUrl, _imageBucket, objectName);
                photoUrl = _fileStorage.GetFileUrl(_imageBucket, objectName);

                return (fileSizeExceeded, photoUrl);
            }
        }
    }
}