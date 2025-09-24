
# TestExercise – Рекламные площадки

## Запуск

1. **Клонировать репозиторий:**
```bash
git clone https://github.com/makar282/TestEx.git
cd TestEx
```
2. **Сборка проекта:**
```bash
dotnet build
```
3. **Запуск веб-сервиса:**
```bash
dotnet run --project TestExercise
```
Swagger UI:
https://localhost:{порт}/swagger/index.html

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
