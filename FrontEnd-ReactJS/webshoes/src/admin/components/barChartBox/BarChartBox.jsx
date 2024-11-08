import { Bar, BarChart, ResponsiveContainer, Tooltip, XAxis } from "recharts";
import "./barChartBox.scss";



const BarChartBox = (props) => {
  return (
    <div className="barChartBox">
      <h1>{props.title}</h1>
      <div className="chart">
        <ResponsiveContainer width="99%" height={150}>
          <BarChart data={props.chartData}>
            <Tooltip
              contentStyle={{ background: "white", borderRadius: "5px" }}
              labelStyle={{ display: "none" }}
              cursor={{fill: 'transparent'}}
            />
            <XAxis dataKey={props.mykey} stroke="white" />
            <Bar dataKey={props.dataKey} fill={props.color} />
          </BarChart>
        </ResponsiveContainer>
      </div>
    </div>
  );
};

export default BarChartBox;