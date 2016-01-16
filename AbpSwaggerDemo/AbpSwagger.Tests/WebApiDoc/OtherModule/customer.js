{
  "tags": [
    {
      "name": "Customer",
      "description": "WebApi help for customer"
    }
  ],
  "securityDefinitions": {},
  "paths": {
    "/api/services/app/customer/GetCustomerByName": {
      "post": {
        "parameters": [
          {
            "in": "query",
            "name": "name",
            "required": true,
            "type": "string",
            "description": "Plese enter name."
          }
        ],
        "tags": [
          "Customer"
        ],
        "summary": "Get  customer by name",
        "operationId": "GetCustomerByName",
        "responses": {
          "200": {
            "description": "OK",
            "schema": {
              "items": {
                "type": "object",
                "$ref": "#/definitions/CustomerListDto"
              },
              "type": "array"
            }
          }
        }
      }
    },
    "/api/services/app/customer/GetCustomerById": {
      "post": {
        "parameters": [
          {
            "in": "body",
            "name": "input",
            "schema": {
              "type": "object",
              "$ref": "#/definitions/IdInput"
            },
            "description": "Plese enter id."
          }
        ],
        "tags": [
          "Customer"
        ],
        "summary": "Get  customer by id",
        "operationId": "GetCustomerById",
        "responses": {
          "200": {
            "description": "OK",
            "schema": {
              "type": "object",
              "$ref": "#/definitions/CustomerListDto"
            }
          }
        }
      }
    }
  },
  "swagger": "2.0",
  "info": {
    "title": "Customer",
    "version": "WebApi help for customer"
  },
  "schemes": [],
  "definitions": {
    "CustomerListDto": {
      "additionalProperties": false,
      "type": "object",
      "required": [
        "Id"
      ],
      "properties": {
        "FirstName": {
          "type": "string"
        },
        "LastName": {
          "type": "string"
        },
        "Address": {
          "type": "string"
        },
        "City": {
          "type": "string"
        },
        "State": {
          "type": "string"
        },
        "Telephone": {
          "type": "string"
        },
        "Email": {
          "type": "string"
        },
        "Id": {
          "type": "integer"
        }
      }
    },
    "IdInput": {
      "additionalProperties": false,
      "type": "object",
      "required": [
        "Id"
      ],
      "properties": {
        "Id": {
          "type": "integer"
        }
      },
      "description": "A shortcut of  for ."
    }
  },
  "responses": {}
}