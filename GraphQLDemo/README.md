# The example is based on the following article

See: https://medium.com/volosoft/building-graphql-apis-with-asp-net-core-419b32a5305b

## Get Started

* Modify the database connection string as needed, then perform the migration.
* Launch the Hotel.Web.Host project, browse http://localhost:21021/ui/playground
* Enter the expression to execute the query.

Input:
```
query TestQuery {
  reservations (roomAllowedSmoking:false, roomStatus: AVAILABLE){
    id
    checkinDate
    checkoutDate
    guest {
      id
      name
      registerDate
    }
    room {
      id
      name
      number
      allowedSmoking
      status
    }
  }
}
```

Output:
```
{
  "data": {
    "reservations": [
      {
        "id": 1,
        "checkinDate": "2019-07-14",
        "checkoutDate": "2019-07-19",
        "guest": null,
        "room": null
      },
      {
        "id": 2,
        "checkinDate": "2019-07-15",
        "checkoutDate": "2019-07-20",
        "guest": null,
        "room": null
      }
    ]
  }
}
```
For more details, please refer to the above article and the documentation of graphql.