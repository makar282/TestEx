
# TestExercise – Рекламные площадки

## Запуск

1. **Клонировать репозиторий:**
```bash
git clone https://github.com/makar282/TestEx.git
cd TestExercise
```
2. **Сборка проекта:**
```bash
dotnet build
```
3. **Запуск веб-сервиса:**
```bash
dotnet run --project TestExercise
```
По умолчанию сервис доступен по адресу:
[https://localhost:7240/](https://localhost:7240/)
Swagger UI:
[https://localhost:7240/swagger/index.html](https://localhost:7240/swagger/index.html)

## API

### 1. Загрузка рекламных площадок из файла

* **Метод:** `POST`
* **URL:** `/api/Platforms/upload`
* **Описание:** Загружает данные из файла `_filePath` и обновляет внутреннее хранилище в памяти.

### 2. Получение рекламных площадок по локации

* **Метод:** `GET`
* **URL:** `/api/Platforms/platforms/{location}`
* **Пример запроса:** `/api/Platforms/platforms/ru/svrd/revda`
* **Описание:** Возвращает список рекламных площадок, действующих для указанной локации и всех родительских префиксов.
