# Library for Modsen #

## Архитектура ##
+ Clean Architecture

## Запуск ##
1. Отредактировать файл appsettings.json, заменив строку подключения.
2. Открыть Package Manager Console.
3. Выбрать Default project: Library.Infrastructure
4. Выполнить команды:
   - add-migration "Init"
   - update-database

## Использование API ##
1. Выполнить запрос Post /api/User. Ввести поля email и password, например (admin@mail.com admin11).
2. Выполнить запрос Post /api/User/authenticate. Ввести поля email и password, например (admin@mail.com admin11).
3. Получить Access токен и скопировать его.
4. Нажать на кнопку Authorize (замочек).
5. Ввести Bearer и вставить токен. Например (Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImF).
6. Теперь доступны операции CRUD для книг.
