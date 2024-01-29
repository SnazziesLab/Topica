<p align="center">
<img height="200" src="Source/Assets/Logo.svg"/>
</p>
<p align="center">
 Topica
</p>
<p align="center">
<a href="https://github.com/SnazziesLab/Topica/releases">
<img src="https://img.shields.io/github/v/release/SnazziesLab/Topica?style=flat-square"/>
</a>
</p>

Topica is an event tracking service designed to make tracking of any given topics and their historical events easily.
This service enables tracking of specific asynchronous jobs' progress or identifying failure points in a data processing pipeline.

See what [scenarios](./Scenarios) this is useful with.

## Setup

### Auth Setup

This app allows use of simple user pass or api key to auth. This is setup via passing a json file like following.

- Auth data is not persistent, the in-memory AuthDb is populated at server startup.

```js
{
  "ApiKeys": [
    {
      "ApiKey": "wawdjawduiJW@IJEDid2ji@JDIjmidaidjmi",
      "Roles": [ "read", "write" ]
    },
    {
      "ApiKey": "aawdwa22",
      "Roles": [ "read" ]
    }
  ],
  "Users": [
    {
      "Username": "admin",
      "Password": "admin",
      "Roles": [ "read", "write" ]
    },
    {
      "Username": "guest",
      "Password": "guest",
      "Roles": [ "read" ]
    }
  ]
}
```

## Service Usage

###### Post job events for `Job1`

Post `/api/Topics/PushMessage?Topic=Job1&Message=job1%created`

Post `/api/Topics/PushMessage?Topic=Job1&Message=job1%processing`

Post `/api/Topics/PushMessage?Topic=Job1&Message=job1%completed`

###### Get all event history of `Job1`

Get `/api/Topics/GetTopic/Job1`

## Roadmap

There is no roadmap as of current. Feature suggestions are welcome.

## License
