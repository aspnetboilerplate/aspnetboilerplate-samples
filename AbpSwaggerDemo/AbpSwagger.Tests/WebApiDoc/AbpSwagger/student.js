{
  "tags": [
    {
      "name": "Student",
      "description": "WebApi help for student"
    }
  ],
  "securityDefinitions": {},
  "paths": {
    "/api/services/app/student/GetStudent": {
      "post": {
        "parameters": [
          {
            "in": "body",
            "name": "input",
            "schema": {
              "type": "object",
              "$ref": "#/definitions/NullableIdInput"
            },
            "description": "Plese enter customer id."
          }
        ],
        "tags": [
          "Student"
        ],
        "summary": "Get student by id.",
        "operationId": "GetStudent",
        "responses": {
          "200": {
            "description": "OK",
            "schema": {
              "type": "object",
              "$ref": "#/definitions/GetStudentForEditOutput"
            }
          }
        }
      }
    },
    "/api/services/app/student/GetStudentById": {
      "post": {
        "parameters": [
          {
            "in": "query",
            "name": "input",
            "required": true,
            "type": "integer",
            "description": "Plese enter customer id."
          }
        ],
        "tags": [
          "Student"
        ],
        "summary": "Get student by id.",
        "operationId": "GetStudentById",
        "responses": {
          "200": {
            "description": "OK",
            "schema": {
              "type": "object",
              "$ref": "#/definitions/GetStudentForEditOutput"
            }
          }
        }
      }
    },
    "/api/services/app/student/GetStudents": {
      "get": {
        "parameters": [],
        "tags": [
          "Student"
        ],
        "summary": "Get all students.",
        "operationId": "GetStudents",
        "responses": {
          "200": {
            "description": "OK",
            "schema": {
              "items": {
                "type": "object",
                "$ref": "#/definitions/StudentListDto"
              },
              "type": "array"
            }
          }
        }
      }
    },
    "/api/services/app/student/GetStudentForPaging": {
      "post": {
        "parameters": [
          {
            "in": "body",
            "name": "input",
            "schema": {
              "type": "object",
              "$ref": "#/definitions/GetStudentInput"
            },
            "description": "Get customer input."
          }
        ],
        "tags": [
          "Student"
        ],
        "summary": "Get student by GetStudentInput.",
        "operationId": "GetStudentForPaging",
        "responses": {
          "200": {
            "description": "OK",
            "schema": {
              "type": "object",
              "$ref": "#/definitions/PagedResultOutputStudentListDto"
            }
          }
        }
      }
    }
  },
  "swagger": "2.0",
  "info": {
    "title": "Student",
    "version": "WebApi help for student"
  },
  "schemes": [],
  "definitions": {
    "NullableIdInput": {
      "additionalProperties": false,
      "type": "object",
      "properties": {
        "Id": {
          "type": "integer"
        }
      },
      "description": "A shortcut of  for ."
    },
    "GetStudentForEditOutput": {
      "additionalProperties": false,
      "type": "object",
      "required": [
        "Id",
        "FirstName",
        "LastName",
        "ClassId"
      ],
      "properties": {
        "Id": {
          "type": "integer",
          "description": "Customer Id"
        },
        "FirstName": {
          "type": "string",
          "description": "First Name"
        },
        "LastName": {
          "type": "string",
          "description": "Last Name"
        },
        "Address": {
          "type": "string",
          "description": "Address"
        },
        "Sno": {
          "type": "string",
          "description": "Student No."
        },
        "ClassId": {
          "type": "integer",
          "description": "Class Id"
        }
      }
    },
    "StudentListDto": {
      "additionalProperties": false,
      "type": "object",
      "required": [
        "ClassId",
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
        "Sno": {
          "type": "string"
        },
        "ClassId": {
          "type": "integer"
        },
        "Id": {
          "type": "integer"
        }
      }
    },
    "GetStudentInput": {
      "additionalProperties": false,
      "type": "object",
      "required": [
        "MaxResultCount",
        "SkipCount",
        "PageIndex"
      ],
      "properties": {
        "MaxResultCount": {
          "type": "integer",
          "maximum": 1000.0,
          "minimum": 1.0
        },
        "SkipCount": {
          "type": "integer",
          "maximum": 2147483647.0,
          "minimum": 0.0
        },
        "PageIndex": {
          "type": "integer",
          "maximum": 2147483647.0,
          "minimum": 0.0
        },
        "Sorting": {
          "type": "string"
        },
        "Filter": {
          "type": "string"
        }
      }
    },
    "PagedResultOutputStudentListDto": {
      "additionalProperties": false,
      "type": "object",
      "required": [
        "TotalCount"
      ],
      "properties": {
        "TotalCount": {
          "type": "integer"
        },
        "Items": {
          "items": {
            "type": "object",
            "$ref": "#/definitions/StudentListDto"
          },
          "type": "array"
        }
      }
    }
  },
  "responses": {}
}