import { ReactNode } from "react";

interface Props {
  children: ReactNode;
}
export const PageLayout: React.FunctionComponent<Props> = (props) => {
  return (
    <div
      style={{
        display: "flex",
        height: "inherit",
        justifyContent: "center",
        alignItems: "center",
        flexDirection: "column",
      }}
    >
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          margin: 50,
          justifyContent: "center",
          borderRadius: "10px",
          alignItems: "center",
        }}
      >
        {props.children}
      </div>
    </div>
  );
};
