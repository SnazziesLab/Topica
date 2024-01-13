# Message

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DateTimeOffset** | **time.Time** |  | 
**Content** | **string** |  | 
**EventUid** | Pointer to **NullableString** |  | [optional] 

## Methods

### NewMessage

`func NewMessage(dateTimeOffset time.Time, content string, ) *Message`

NewMessage instantiates a new Message object
This constructor will assign default values to properties that have it defined,
and makes sure properties required by API are set, but the set of arguments
will change when the set of required properties is changed

### NewMessageWithDefaults

`func NewMessageWithDefaults() *Message`

NewMessageWithDefaults instantiates a new Message object
This constructor will only assign default values to properties that have it defined,
but it doesn't guarantee that properties required by API are set

### GetDateTimeOffset

`func (o *Message) GetDateTimeOffset() time.Time`

GetDateTimeOffset returns the DateTimeOffset field if non-nil, zero value otherwise.

### GetDateTimeOffsetOk

`func (o *Message) GetDateTimeOffsetOk() (*time.Time, bool)`

GetDateTimeOffsetOk returns a tuple with the DateTimeOffset field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetDateTimeOffset

`func (o *Message) SetDateTimeOffset(v time.Time)`

SetDateTimeOffset sets DateTimeOffset field to given value.


### GetContent

`func (o *Message) GetContent() string`

GetContent returns the Content field if non-nil, zero value otherwise.

### GetContentOk

`func (o *Message) GetContentOk() (*string, bool)`

GetContentOk returns a tuple with the Content field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetContent

`func (o *Message) SetContent(v string)`

SetContent sets Content field to given value.


### GetEventUid

`func (o *Message) GetEventUid() string`

GetEventUid returns the EventUid field if non-nil, zero value otherwise.

### GetEventUidOk

`func (o *Message) GetEventUidOk() (*string, bool)`

GetEventUidOk returns a tuple with the EventUid field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetEventUid

`func (o *Message) SetEventUid(v string)`

SetEventUid sets EventUid field to given value.

### HasEventUid

`func (o *Message) HasEventUid() bool`

HasEventUid returns a boolean if a field has been set.

### SetEventUidNil

`func (o *Message) SetEventUidNil(b bool)`

 SetEventUidNil sets the value for EventUid to be an explicit nil

### UnsetEventUid
`func (o *Message) UnsetEventUid()`

UnsetEventUid ensures that no value is present for EventUid, not even an explicit nil

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


