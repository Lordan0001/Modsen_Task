# Library for Modsen #

## Архитектура ##
+ Clean Architecture

## Запуск ##
1. Отредактировать файл appsettings.json, заменив строку подключения.
2. Открыть Package Manager Console.
3. Выполнить команды:
   - add-migration "Init"
   - update-database

## Использование API ##
1. Выполнить запрос Post /api/User. Изменить только поле userEmail, например (admin@mail.com).
2. Выполнить запрос Post /api/User/authenticate. Изменить только поле userEmail, например (admin@mail.com).
3. Получить Access токен и скопировать его.
4. Нажать на кнопку Authorize (замочек).
5. Ввести Bearer и вставить токен. Например (Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImF).
6. Теперь доступны операции CRUD для книг.
