/* tslint:disable */
/* eslint-disable */
/**
 * Topica.Server, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { exists, mapValues } from '../runtime';
import type { TopicMeta } from './TopicMeta';
import {
    TopicMetaFromJSON,
    TopicMetaFromJSONTyped,
    TopicMetaToJSON,
} from './TopicMeta';

/**
 * 
 * @export
 * @interface TopicMetaPaginatedResponse
 */
export interface TopicMetaPaginatedResponse {
    /**
     * 
     * @type {Array<TopicMeta>}
     * @memberof TopicMetaPaginatedResponse
     */
    data?: Array<TopicMeta> | null;
    /**
     * 
     * @type {number}
     * @memberof TopicMetaPaginatedResponse
     */
    page?: number;
    /**
     * 
     * @type {number}
     * @memberof TopicMetaPaginatedResponse
     */
    pageSize?: number;
    /**
     * 
     * @type {number}
     * @memberof TopicMetaPaginatedResponse
     */
    total?: number;
}

/**
 * Check if a given object implements the TopicMetaPaginatedResponse interface.
 */
export function instanceOfTopicMetaPaginatedResponse(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function TopicMetaPaginatedResponseFromJSON(json: any): TopicMetaPaginatedResponse {
    return TopicMetaPaginatedResponseFromJSONTyped(json, false);
}

export function TopicMetaPaginatedResponseFromJSONTyped(json: any, ignoreDiscriminator: boolean): TopicMetaPaginatedResponse {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'data': !exists(json, 'data') ? undefined : (json['data'] === null ? null : (json['data'] as Array<any>).map(TopicMetaFromJSON)),
        'page': !exists(json, 'page') ? undefined : json['page'],
        'pageSize': !exists(json, 'pageSize') ? undefined : json['pageSize'],
        'total': !exists(json, 'total') ? undefined : json['total'],
    };
}

export function TopicMetaPaginatedResponseToJSON(value?: TopicMetaPaginatedResponse | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'data': value.data === undefined ? undefined : (value.data === null ? null : (value.data as Array<any>).map(TopicMetaToJSON)),
        'page': value.page,
        'pageSize': value.pageSize,
        'total': value.total,
    };
}

