/*
Topica.Server, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)

API version: 1.0
*/

// Code generated by OpenAPI Generator (https://openapi-generator.tech); DO NOT EDIT.

package Topica.Client

import (
	"encoding/json"
	"time"
)

// checks if the Entry type satisfies the MappedNullable interface at compile time
var _ MappedNullable = &Entry{}

// Entry struct for Entry
type Entry struct {
	CreatedOn *time.Time `json:"createdOn,omitempty"`
	Content NullableString `json:"content,omitempty"`
	EntryId *string `json:"entryId,omitempty"`
}

// NewEntry instantiates a new Entry object
// This constructor will assign default values to properties that have it defined,
// and makes sure properties required by API are set, but the set of arguments
// will change when the set of required properties is changed
func NewEntry() *Entry {
	this := Entry{}
	return &this
}

// NewEntryWithDefaults instantiates a new Entry object
// This constructor will only assign default values to properties that have it defined,
// but it doesn't guarantee that properties required by API are set
func NewEntryWithDefaults() *Entry {
	this := Entry{}
	return &this
}

// GetCreatedOn returns the CreatedOn field value if set, zero value otherwise.
func (o *Entry) GetCreatedOn() time.Time {
	if o == nil || IsNil(o.CreatedOn) {
		var ret time.Time
		return ret
	}
	return *o.CreatedOn
}

// GetCreatedOnOk returns a tuple with the CreatedOn field value if set, nil otherwise
// and a boolean to check if the value has been set.
func (o *Entry) GetCreatedOnOk() (*time.Time, bool) {
	if o == nil || IsNil(o.CreatedOn) {
		return nil, false
	}
	return o.CreatedOn, true
}

// HasCreatedOn returns a boolean if a field has been set.
func (o *Entry) HasCreatedOn() bool {
	if o != nil && !IsNil(o.CreatedOn) {
		return true
	}

	return false
}

// SetCreatedOn gets a reference to the given time.Time and assigns it to the CreatedOn field.
func (o *Entry) SetCreatedOn(v time.Time) {
	o.CreatedOn = &v
}

// GetContent returns the Content field value if set, zero value otherwise (both if not set or set to explicit null).
func (o *Entry) GetContent() string {
	if o == nil || IsNil(o.Content.Get()) {
		var ret string
		return ret
	}
	return *o.Content.Get()
}

// GetContentOk returns a tuple with the Content field value if set, nil otherwise
// and a boolean to check if the value has been set.
// NOTE: If the value is an explicit nil, `nil, true` will be returned
func (o *Entry) GetContentOk() (*string, bool) {
	if o == nil {
		return nil, false
	}
	return o.Content.Get(), o.Content.IsSet()
}

// HasContent returns a boolean if a field has been set.
func (o *Entry) HasContent() bool {
	if o != nil && o.Content.IsSet() {
		return true
	}

	return false
}

// SetContent gets a reference to the given NullableString and assigns it to the Content field.
func (o *Entry) SetContent(v string) {
	o.Content.Set(&v)
}
// SetContentNil sets the value for Content to be an explicit nil
func (o *Entry) SetContentNil() {
	o.Content.Set(nil)
}

// UnsetContent ensures that no value is present for Content, not even an explicit nil
func (o *Entry) UnsetContent() {
	o.Content.Unset()
}

// GetEntryId returns the EntryId field value if set, zero value otherwise.
func (o *Entry) GetEntryId() string {
	if o == nil || IsNil(o.EntryId) {
		var ret string
		return ret
	}
	return *o.EntryId
}

// GetEntryIdOk returns a tuple with the EntryId field value if set, nil otherwise
// and a boolean to check if the value has been set.
func (o *Entry) GetEntryIdOk() (*string, bool) {
	if o == nil || IsNil(o.EntryId) {
		return nil, false
	}
	return o.EntryId, true
}

// HasEntryId returns a boolean if a field has been set.
func (o *Entry) HasEntryId() bool {
	if o != nil && !IsNil(o.EntryId) {
		return true
	}

	return false
}

// SetEntryId gets a reference to the given string and assigns it to the EntryId field.
func (o *Entry) SetEntryId(v string) {
	o.EntryId = &v
}

func (o Entry) MarshalJSON() ([]byte, error) {
	toSerialize,err := o.ToMap()
	if err != nil {
		return []byte{}, err
	}
	return json.Marshal(toSerialize)
}

func (o Entry) ToMap() (map[string]interface{}, error) {
	toSerialize := map[string]interface{}{}
	if !IsNil(o.CreatedOn) {
		toSerialize["createdOn"] = o.CreatedOn
	}
	if o.Content.IsSet() {
		toSerialize["content"] = o.Content.Get()
	}
	if !IsNil(o.EntryId) {
		toSerialize["entryId"] = o.EntryId
	}
	return toSerialize, nil
}

type NullableEntry struct {
	value *Entry
	isSet bool
}

func (v NullableEntry) Get() *Entry {
	return v.value
}

func (v *NullableEntry) Set(val *Entry) {
	v.value = val
	v.isSet = true
}

func (v NullableEntry) IsSet() bool {
	return v.isSet
}

func (v *NullableEntry) Unset() {
	v.value = nil
	v.isSet = false
}

func NewNullableEntry(val *Entry) *NullableEntry {
	return &NullableEntry{value: val, isSet: true}
}

func (v NullableEntry) MarshalJSON() ([]byte, error) {
	return json.Marshal(v.value)
}

func (v *NullableEntry) UnmarshalJSON(src []byte) error {
	v.isSet = true
	return json.Unmarshal(src, &v.value)
}


