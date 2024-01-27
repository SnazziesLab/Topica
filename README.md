# Event Tracking Service

## Description

Zevents is an event tracking service designed to make tracking of any given topics and their historical events easily.
This service enables tracking of specific asynchronous jobs' progress or identifying failure points in a data processing pipeline.

See what [scenarios](./Scenarios) this is useful with.


## Usage

###### Post job events for `Job1`
Post `/api/Topics/PushMessage?Topic=Job1&Message=job1%created`

Post `/api/Topics/PushMessage?Topic=Job1&Message=job1%processing`

Post `/api/Topics/PushMessage?Topic=Job1&Message=job1%completed`

###### Get all event history of `Job1`

Get `/api/Topics/GetTopic/Job1`

## Roadmap

There is no roadmap as of current. Feature suggestions are welcome. 

## License
