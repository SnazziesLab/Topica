import { useRequest } from "ahooks";
import { Button, Card, Input, Table } from "antd";
import React, { useState } from "react";
import { topicsApi } from "../api/api";

export const DashboardPage: React.FunctionComponent = () => {
  const [search, setSearch] = useState("");
    const {data} = useRequest(() => topicsApi.getTopics());

    const rows = data?.map(e=> { return {key:e}});

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
        <div
          style={{
            gap: "15px",
            display: "flex",
            alignSelf: "flex-start",
            marginBottom: 15,
          }}
        >
          <div>
            <Card>
              <div
                style={{
                  display: "flex",
                  flexDirection: "column",
                  alignItems: "center",
                  justifyContent: "center",
                }}
              >
                <h3>Total Topics</h3>
                <div style={{fontWeight:"bold", fontSize:"1.5rem"}}>30</div>
              </div>
            </Card>
          </div>
        </div>
        <div
          style={{
            gap: "15px",
            display: "flex",
            alignSelf: "flex-start",
            marginBottom: 15,
          }}
        >
          <Button type="primary">New Topic</Button>
          <Button type="primary">New Message</Button>
          <Button disabled danger type="primary">
            Delete
          </Button>
        </div>
        <div
          style={{ display: "flex", flexDirection: "column", width: "800px" }}
        >
          <Input
            value={search}
            onChange={(e) => setSearch(e.target.value)}
            placeholder="Search"
          />
          <Table columns={columns} dataSource={rows ?? undefined}></Table>
        </div>
      </div>
    </div>
  );
};

const columns = [
    {
      title: 'Topic',
      dataIndex: 'topicId',
      key: 'topicId',
    },
    {
      title: 'Entries',
      dataIndex: 'address',
      key: 'entrys',
    },
  ];