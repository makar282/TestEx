Клонировать репозиторий:
  git clone https://github.com/yourusername/TestExercise.git
  cd TestExercise
Сборка проекта:
  dotnet build
Запуск веб-сервиса:
  dotnet run --project TestExercise
По умолчанию сервис доступен по адресу: https://localhost:7240/
Swagger: https://localhost:7240/swagger/index.html

API
Загрузка рекламных площадок из файла
Метод: POST
URL: /api/Platforms/upload
Описание: Загружает данные из файла _filePath и обновляет внутреннее хранилище в памяти.

Получение рекламных площадок по локации
Метод: GET
URL: /api/Platforms/platforms/{location}
Пример запроса: /api/Platforms/platforms/ru/svrd/revda
Описание: Возвращает список рекламных площадок, действующих для указанной локации и всех родительских префиксов.
