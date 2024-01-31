import { useRequest } from "ahooks";
import { Button, Card, Input, Table } from "antd";
import React, { useEffect, useState } from "react";
import { topicsApi } from "../api/api";
import { ColumnsType } from "antd/es/table";
import { TopicMeta } from "@topica/client";
import { PageLayout } from "../Components/PageLayout";
import { CreateTopic } from "../Components/CreateTopic";

export const DashboardPage: React.FunctionComponent = () => {
  const [search, setSearch] = useState("");
  const { data: total } = useRequest(() => topicsApi.getTotal(), {
    pollingInterval: 5000,
  });
  const [page, setPage] = useState({ page: 0, pageSize: 10 });
  const { data, refresh: refreshData } = useRequest(() =>
    topicsApi.getTopics({ ...page, search: search })
  );

  useEffect(() => {
    refreshData();
  }, [search, page.page, page.pageSize]);

  return (
    <PageLayout>
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
              <div style={{ fontWeight: "bold", fontSize: "1.5rem" }}>
                {total}
              </div>
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
        <CreateTopic/>
        <Button type="primary">Create Message</Button>
        <Button onClick={refreshData}>Refresh</Button>
        <Button disabled danger type="primary">
          Delete
        </Button>
      </div>
      <div style={{ display: "flex", flexDirection: "column", width: "800px" }}>
        <Input
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          placeholder="Search"
        />

        <Table
          columns={columns}
          pagination={{
            pageSize: page.pageSize,
            defaultPageSize: page.pageSize,
            current: page.page + 1,
            position: ["topRight", "bottomRight"],
            total: data?.total,
            showSizeChanger: true,
            pageSizeOptions: [10, 25, 50, 100],
            onChange: (page, pageSize) => {
              setPage({ page: page - 1, pageSize });
            },
          }}
          size="small"
          dataSource={data?.data ?? undefined}
        ></Table>
      </div>
    </PageLayout>
  );
};

const columns: ColumnsType<TopicMeta> = [
  {
    title: "Topic",
    dataIndex: "id",
    key: "id",
  },
  {
    title: "Created On",
    key: "createdOn",
    dataIndex: "createdOn",
    sorter: (v, n) =>
      new Date(v.createdOn!).getTime() - new Date(n.createdOn!).getTime(),
    defaultSortOrder: "ascend",
    render: (v) => new Date(v).toUTCString(),
  },
];

