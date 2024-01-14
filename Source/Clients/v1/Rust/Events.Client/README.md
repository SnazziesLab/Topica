# Rust API client for Events.Client

No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)


## Overview

This API client was generated by the [OpenAPI Generator](https://openapi-generator.tech) project.  By using the [openapi-spec](https://openapis.org) from a remote server, you can easily generate an API client.

- API version: 1.0
- Package version: 1.0.0
- Build package: `org.openapitools.codegen.languages.RustClientCodegen`

## Installation

Put the package under your project folder in a directory named `Events.Client` and add the following to `Cargo.toml` under `[dependencies]`:

```
Events.Client = { path = "./Events.Client" }
```

## Documentation for API Endpoints

All URIs are relative to *http://localhost*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*EventsApi* | [**delete_event**](docs/EventsApi.md#delete_event) | **DELETE** /Events | 
*EventsApi* | [**get_events**](docs/EventsApi.md#get_events) | **GET** /Events | 
*EventsApi* | [**update_event**](docs/EventsApi.md#update_event) | **PUT** /Events | 
*SinkApi* | [**sink_put**](docs/SinkApi.md#sink_put) | **PUT** /Sink | 


## Documentation For Models

 - [Event](docs/Event.md)
 - [Message](docs/Message.md)


To get access to the crate's generated documentation, use:

```
cargo doc --open
```

## Author


