# Event

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Uid** | Pointer to **NullableString** |  | [optional] 
**CreatedOn** | Pointer to **time.Time** |  | [optional] 
**Description** | Pointer to **NullableString** |  | [optional] 
**History** | Pointer to [**map[string]Message**](Message.md) |  | [optional] 

## Methods

### NewEvent

`func NewEvent() *Event`

NewEvent instantiates a new Event object
This constructor will assign default values to properties that have it defined,
and makes sure properties required by API are set, but the set of arguments
will change when the set of required properties is changed

### NewEventWithDefaults

`func NewEventWithDefaults() *Event`

NewEventWithDefaults instantiates a new Event object
This constructor will only assign default values to properties that have it defined,
but it doesn't guarantee that properties required by API are set

### GetUid

`func (o *Event) GetUid() string`

GetUid returns the Uid field if non-nil, zero value otherwise.

### GetUidOk

`func (o *Event) GetUidOk() (*string, bool)`

GetUidOk returns a tuple with the Uid field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetUid

`func (o *Event) SetUid(v string)`

SetUid sets Uid field to given value.

### HasUid

`func (o *Event) HasUid() bool`

HasUid returns a boolean if a field has been set.

### SetUidNil

`func (o *Event) SetUidNil(b bool)`

 SetUidNil sets the value for Uid to be an explicit nil

### UnsetUid
`func (o *Event) UnsetUid()`

UnsetUid ensures that no value is present for Uid, not even an explicit nil
### GetCreatedOn

`func (o *Event) GetCreatedOn() time.Time`

GetCreatedOn returns the CreatedOn field if non-nil, zero value otherwise.

### GetCreatedOnOk

`func (o *Event) GetCreatedOnOk() (*time.Time, bool)`

GetCreatedOnOk returns a tuple with the CreatedOn field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetCreatedOn

`func (o *Event) SetCreatedOn(v time.Time)`

SetCreatedOn sets CreatedOn field to given value.

### HasCreatedOn

`func (o *Event) HasCreatedOn() bool`

HasCreatedOn returns a boolean if a field has been set.

### GetDescription

`func (o *Event) GetDescription() string`

GetDescription returns the Description field if non-nil, zero value otherwise.

### GetDescriptionOk

`func (o *Event) GetDescriptionOk() (*string, bool)`

GetDescriptionOk returns a tuple with the Description field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetDescription

`func (o *Event) SetDescription(v string)`

SetDescription sets Description field to given value.

### HasDescription

`func (o *Event) HasDescription() bool`

HasDescription returns a boolean if a field has been set.

### SetDescriptionNil

`func (o *Event) SetDescriptionNil(b bool)`

 SetDescriptionNil sets the value for Description to be an explicit nil

### UnsetDescription
`func (o *Event) UnsetDescription()`

UnsetDescription ensures that no value is present for Description, not even an explicit nil
### GetHistory

`func (o *Event) GetHistory() map[string]Message`

GetHistory returns the History field if non-nil, zero value otherwise.

### GetHistoryOk

`func (o *Event) GetHistoryOk() (*map[string]Message, bool)`

GetHistoryOk returns a tuple with the History field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetHistory

`func (o *Event) SetHistory(v map[string]Message)`

SetHistory sets History field to given value.

### HasHistory

`func (o *Event) HasHistory() bool`

HasHistory returns a boolean if a field has been set.

### SetHistoryNil

`func (o *Event) SetHistoryNil(b bool)`

 SetHistoryNil sets the value for History to be an explicit nil

### UnsetHistory
`func (o *Event) UnsetHistory()`

UnsetHistory ensures that no value is present for History, not even an explicit nil

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


