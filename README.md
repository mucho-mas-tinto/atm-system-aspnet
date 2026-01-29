# ATM System

Система банкомата на ASP.NET с луковой архитектурой.

## Возможности

- Сессии (пользовательские и админские), их создание
- Создание пользовательских счетов
- Пополнение и снятие средств со счетов
- Просмотр баланса и истории операций счета

## Архитектура

- Луковая Архитектура
- MSDI для dependency injection
- In-memory репозитории

## Запуск 

```bash
# Собрать проект
dotnet build

# Запустить API
dotnet run --project src/AtmSystem/AtmSystem.csproj

# Запустить тесты
dotnet test
```

## API Documentation
После запуска Swagger доступен по адресу:
```bash
http://localhost:5029/swagger
```

## CI/CD
.NET Build & Test
- Автоматическая сборка и тестирование при push/PR
- GitHub Actions workflow

## Тесты
- Unit тесты бизнес-логики
- Моки репозиториев
- Покрытие: снятие/пополнение средств
