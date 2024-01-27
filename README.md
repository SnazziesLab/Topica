# Zevents

Zevents is an event tracking service designed to make tracking of any given topics and their historical events easily.
This service enables tracking of specific asynchronous jobs' progress or identifying failure points in a data processing pipeline.

See what [scenarios](./Scenarios) this is useful with.


## Setup

### Auth Setup
This app uses a simple username and password system. This is setup via passing a json file like following.
```js
[
  {
    "username": "UIAdmin",
    "password": "password",
    "roles": [ "read", "write" ]
  },
  {
    "username": "UIGuest",
    "password": "password",
    "roles": [ "read" ]
  },
  {
    "username": "service",
    "password": "password",
    "roles": [ "read", "write" ]
  },
  {
    "username": "readonly",
    "password": "password",
    "roles": [ "read" ]
  }
]
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
