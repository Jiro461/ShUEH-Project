import { Cell, Pie, PieChart, ResponsiveContainer, Tooltip } from "recharts";
import "./pieChartBox.scss";

const PieChartBox = (props) => {
  return (
    <div className="pieChartBox">
      <h1>{props.title}</h1>
      <div className="chart">
        <ResponsiveContainer width="99%" height={300}>
          <PieChart>
            <Tooltip
              contentStyle={{ background: "white", borderRadius: "5px" }}
            />
            <Pie
              data={props.data}
              innerRadius={"70%"}
              outerRadius={"90%"}
              paddingAngle={5}
              dataKey={props.myDataKey}
              nameKey={props.myValueKey}
            >
              {props.data.map((item, index) => (
                <Cell 
                  key={`${item?.[props.myValueKey]} - ${index}`}  // Ensure uniqueness by combining valueKey with index
                  fill={item.color || "#ccc"}  // Default color if undefined
                />
              ))}
            </Pie>
          </PieChart>
        </ResponsiveContainer>
      </div>
      <div className="options">
        {props.data.map((item, index) => (
          <div className="option" key={`${item?.[props.myValueKey]}-${index}`}>
            <div className="title">
              <div className="dot" style={{ backgroundColor: item.color || "#ccc" }} />
              <span>{item?.[props.myValueKey]}</span>
            </div>
            <span>{item?.[props.myDataKey]}</span>
          </div>
        ))}
      </div>
    </div>
  );
};

export default PieChartBox;
