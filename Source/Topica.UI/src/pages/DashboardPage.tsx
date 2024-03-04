import { useLocalStorageState, useRequest } from "ahooks";
import { Button, Card, Input, Modal, Table } from "antd";
import React, { useEffect, useState } from "react";
import { topicsApi } from "../api/api";
import { ColumnsType } from "antd/es/table";
import { TopicMeta } from "@topica/client";
import { PageLayout } from "../Components/PageLayout";
import { CreateTopic } from "../Components/CreateTopic";
import { CreateMessage } from "../Components/CreateMessage";
import { useNavigate } from "react-router-dom";

export const DashboardPage: React.FunctionComponent = () => {
	const [search, setSearch] = useState("");
	const { data: total } = useRequest(() => topicsApi.getTotal(), {
		pollingInterval: 5000,
	});
	const [pagination, setPagination] = useLocalStorageState<number>(
		"pagination",
		{ defaultValue: 10 },
	);

	const [page, setPage] = useState({ page: 0, pageSize: pagination ?? 10 });
	const navigate = useNavigate();
	const { data, run, loading, refresh } = useRequest(
		(search: string, page: { page: number; pageSize: number }) =>
			topicsApi.getTopics({ ...page, search: search }),
	);

	useEffect(() => {
		run(search, { page: page.page, pageSize: page.pageSize });
	}, [search, page]);

	return (
		<>
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
					<CreateTopic />
					<CreateMessage />
					<Button onClick={refresh}>Refresh</Button>
				</div>
				<div
					style={{ display: "flex", flexDirection: "column", width: "800px" }}
				>
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
								setPagination(pageSize);
								setPage({ page: page - 1, pageSize });
							},
						}}
						size="small"
						loading={loading}
						dataSource={data?.data ?? undefined}
						rowClassName={"custom-row-hover"}
						onRow={(record, rowIndex) => {
							return {
								onClick: (event) => {
									navigate(`/${record.id}`);
								},
							};
						}}
					/>
				</div>
			</PageLayout>
		</>
	);
};

const columns: ColumnsType<TopicMeta> = [
	{
		title: "Topic",
		dataIndex: "id",
	},
	{
		title: "Created On",
		dataIndex: "createdOn",
		render: (v) => new Date(v).toUTCString(),
	},
];
