import Estimate from "./Estimate";

export default function EstimateList(props) {
    return (
    <>
    <div className="mt-3">
        {props.estimates.map((est) => (
          <Estimate
            key={est.id}
            est={est}
          />
        ))}
      </div>
    </>
    )
  }