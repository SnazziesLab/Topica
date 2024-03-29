import { Button, Form, Input, Modal } from "antd";
import React, { useState } from "react";
import { topicsApi } from "../api/api";
import { useCounter, useRequest } from "ahooks";

export const CreateTopic: React.FunctionComponent = () => {
  const [open, setOpen] = useState(false);
  const [form] = Form.useForm<string>();
  const [successCounter, setSuccessCounter] = useCounter(0);
  const [addButtonText, setAddButtonText] = useState<
    "Add" | "Add Another" | string
  >("Add");
  const {
    data,
    error,
    refresh: sendRequest,
  } = useRequest(
    () =>
      topicsApi
        .createTopic({ topicId: form.getFieldValue("id") })
        .then((result) => {
          setAddButtonText(
            `Add Another${successCounter > 0 ? `(${successCounter})` : ""}`
          );

          setSuccessCounter.inc(1);
          return result;
        }),
    { manual: true }
  );
  function handleClose() {
    setOpen(false);
    form.resetFields();
  }

  function handleSubmit() {
    sendRequest();
  }
  return (
    <>
      <Button type="primary" onClick={() => setOpen(true)}>
        Create Topic
      </Button>
      <Modal
        open={open}
        title="Create Topic"
        centered
        afterClose={handleClose}
        closable
        onCancel={handleClose}
        maskClosable={true}
        footer={[
          <Button type="primary" onClick={handleSubmit}>
            {addButtonText}
          </Button>,
        ]}
      >
        <Form form={form} onFinish={handleSubmit}>
          <Form.Item
            name={"id"}
            label="Topic"
            help="If left empty, a GUID will be generated."
          >
            <Input placeholder="Name of topic" defaultValue={""}></Input>
          </Form.Item>
        </Form>
        {data && !error && <div>Success: {data}</div>}
        {error && <div>Error: {error.message}</div>}
      </Modal>
    </>
  );
};
