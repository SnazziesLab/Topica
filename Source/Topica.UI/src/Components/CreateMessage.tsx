import { Button, Form, Input, Modal } from "antd";
import React, { useState } from "react";
import { messageApi } from "../api/api";
import { useCounter, useRequest } from "ahooks";
import TextArea from "antd/es/input/TextArea";

export const CreateMessage: React.FunctionComponent = () => {
  const [open, setOpen] = useState(false);
  const [form] = Form.useForm();
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
      messageApi
        .addMessage({
          topicId: form.getFieldValue("id"),
          body: form.getFieldValue("message"),
        })
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
        Create Message
      </Button>
      <Modal
        open={open}
        title="Create Message"
        centered
        afterClose={handleClose}
        closable
        onCancel={handleClose}
        maskClosable={true}
        footer={[
          <Button type="primary" onClick={form.submit}>
            {addButtonText}
          </Button>,
        ]}
      >
        <Form form={form} onFinish={handleSubmit}>
          <Form.Item
            name={"id"}
            label="Topic"
            help="If left empty, a new Topic will be created with a GUID"
          >
            <Input placeholder="Name of topic" />
          </Form.Item>
          <Form.Item
            name={"message"}
            label="Message"
            rules={[
              { required: true },
              { min: 1, message: "Message must not be empty" },
            ]}
          >
            <TextArea placeholder="Message" rows={4} />
          </Form.Item>
        </Form>
        {data && !error && <div>Success: {data}</div>}
        {error && <div>Error: {error.message}</div>}
      </Modal>
    </>
  );
};
