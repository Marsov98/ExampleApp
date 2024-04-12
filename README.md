# ExampleApp

## Add API
* изменил DI на Singelton
* создал CRUD операции для Users
* добавил Cors

### Документация API
 * > GET https://localhost:7032/api/Users
 Response body
 ```json
    [
  {
    "id": 1,
    "name": "user1"
  },
  {
    "id": 2,
    "name": "user2"
  }
]
 ```

 * > GET https://localhost:7032/api/Users/3
 Response body
 ```json
 {
  "id": 2,
  "name": "user2"
}
 ```

 * > POST https://localhost:7032/api/Users
 Request body
```json
 {
  "id": 3,
  "name": "oleg"
}
 ```

 * PUT > https://localhost:7032/api/Users/UpdateUser
  Request body
```json
 {
  "id": 3,
  "name": "andrey"
}
 ```

 * DELETE  > https://localhost:7032/api/Users/DeleteUser?id=3


## Android

Создал мобильное приложение с CRUD операциями