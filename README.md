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
<img src="https://github.com/SnazziesLab/Topica/actions/workflows/docker-publish.yml/badge.svg?branch=master"/>
</p>

Topica is an event/topic tracking provider designed to make tracking any given topics and their history easily.
This service enables tracking of specific asynchronous jobs' progress or identifying failure points in a data processing pipeline.

See what [scenarios](./Scenarios) topica can help with.

## License

All rights reserved.
I will eventually pick the right license for this project.

You're free to use Topica in your own projects or in commercial settings free of charge. I am not liable for any damages caused.

Rights to contribution made is transfered to repo owner immediately upon submission unless specified otherwise.

| Permissions       | Limitations      |
| ----------------- | ---------------- |
| ✅ Private use    | ❌ Distribution  |
| ✅ Modification   | ❌ Trademark use |
| ✅ Commercial use | ❌ Patent use    |
|                   | ❌ Warranty      |
|                   | ❌ Liability     |

## Example docker-compose

1. `cd Example`
2. `docker-compose up`

## Setup

### Env Variables

| name                          | Description                                                          | Options                                               |
| ----------------------------- | -------------------------------------------------------------------- | ----------------------------------------------------- |
| SecretKey                     | Long secret string used for creating Symmetric Security Key at login | `string`                                              |
| DbType                        | Db type used to store app data                                       | `'Postgres'`, `'SqlServer'`, `'Sqlite'`, `'InMemory'` |
| DbConnectionString (Optional) | Db connection string for none in-memory Db                           | `string`                                              |

### Auth Config (auth.config.json)

This app allows use of simple user pass or api key to auth. This is setup via passing a json file like following.

- Auth data is not persistent, the in-memory AuthDb is populated at server startup.

https://github.com/SnazziesLab/Topica/blob/670e8ab548d70e71bc9447210ff778b4fc4f820f/Example/auth.config.json#L1-L24

## API

See [Open API Spec](./Source/Topica.Server/Topica.Server/Swagger/Swagger.json)

## Usage

### Clients

Using open api generator, a bunch of http clients can help you easily communicate with the server api through your app.
See [Clients]("./Source/Clients).

### Basic usage concept

##### Post job events for `Job1`

Post `/api/messages`
Body: `Job1 created`
Response: `529f884e-a611-44f8-b73b-0140d5c26b63`

Post `/api/messages?Topic=529f884e-a611-44f8-b73b-0140d5c26b63`
Body: `service1: processing`

Post `/api/messages?Topic=529f884e-a611-44f8-b73b-0140d5c26b63`
Body: `service2: processing`

Post `/api/messages?Topic=529f884e-a611-44f8-b73b-0140d5c26b63`
Body: `completed`

##### Get all event history of `Job1`

Get `/api/Topics/Job1`

## Roadmap

There are currently no major features planned. Feature suggestions are welcome.

See [milestones](https://github.com/SnazziesLab/Topica/milestones) for things being currently worked on.
