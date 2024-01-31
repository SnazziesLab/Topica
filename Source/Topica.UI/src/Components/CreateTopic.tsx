import { TopicMeta } from "@topica/client";
import { Button, Form, Input, Modal } from "antd";
import React, { useState } from "react";
import { topicsApi } from "../api/api";
import { useRequest } from "ahooks";

export const CreateTopic: React.FunctionComponent = (props) => {
  const [open, setOpen] = useState(false);
  const [form] = Form.useForm<string>();
  const [addButtonText, setAddButtonText] = useState<"Add"|"Add Another">("Add")
  const {data, error, refresh: sendRequest} = useRequest(() => topicsApi.createTopic({ topicId: form.getFieldValue("id") }), {manual:true});
  function handleSubmit() {
    form
      .validateFields({ validateOnly: true })
      .then((id) => {
        sendRequest();
        setAddButtonText("Add Another")
      })
      .catch((error) => {
      });
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
        footer={[
          <Button>Cancel</Button>,
          <Button type="primary" onClick={handleSubmit}>
            {addButtonText}
          </Button>,
        ]}
      >
        <Form form={form}>
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
