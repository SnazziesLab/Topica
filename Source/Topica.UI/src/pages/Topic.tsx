import { useRequest } from "ahooks";
import React, { useEffect } from "react";
import { topicsApi } from "../api/api";
import { Skeleton, Divider, List, Avatar, Button } from "antd";
import { useNavigate, useParams } from "react-router-dom";
import ErrorBoundary from "antd/es/alert/ErrorBoundary";
export const Topic: React.FunctionComponent = (props) => {
	const params = useParams<{ id: string }>();
	const { data, error, loading, run } = useRequest(
		() => topicsApi.getTopic({ topicId: params.id ?? "" }),
		{ manual: true },
	);

	const { deleteError, run: Delete } = useRequest(
		() => topicsApi.deleteTopic({ topicId: params.id ?? "" }),
		{ manual: true },
	);

	const navigate = useNavigate();

	useEffect(() => {
		run();
	}, [run]);

	return (
		<div>
			<Button type="primary" onClick={() => navigate("/")}>
				Back
			</Button>
			<div style={{ display: "flex", gap: 10 }}>
				<h2>Topic Id: {data?.id}</h2>
				<Button
					type="primary"
					style={{ alignSelf: "center" }}
					danger
					onClick={Delete}
				>
					Delete Topic
				</Button>
			</div>
			<h4>Message Count: {data?.history?.length}</h4>
			<ErrorBoundary message={error?.message}>
				<div
					id="scrollableDiv"
					style={{
						height: 400,
						overflow: "auto",
						padding: "0 16px",
						border: "1px solid rgba(140, 140, 140, 0.35)",
					}}
				>
					<List
						dataSource={data?.history ?? undefined}
						loading={loading}
						renderItem={(item) => (
							<List.Item key={item.createdOn?.toUTCString()}>
								<List.Item.Meta
									title={
										<div>
											{item.createdOn?.toISOString()} | id: {item.entryId}
										</div>
									}
									description={<p>{item.content}</p>}
								/>
							</List.Item>
						)}
					/>
				</div>
			</ErrorBoundary>
		</div>
	);
};
