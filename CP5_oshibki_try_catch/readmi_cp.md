<img width="1568" height="641" alt="image" src="https://github.com/user-attachments/assets/e0cb05b9-d578-44e2-bd75-655f3f110693" />

Вариант 1. ConfigConverter (конвертер настроек)
Метод int GetInt(Dictionary<string, string> config, string key): ищет key в словаре; если ключа нет — ловит KeyNotFoundException и бросает новое InvalidOperationException с понятным сообщением, InnerException и Data["ConfigKey"] = key.
Тот же метод: если значение найдено, но не парсится как int — ловит FormatException и бросает новое InvalidOperationException с InnerException, Data["ConfigKey"] и Data["RawValue"].
В вызывающем коде поймайте InvalidOperationException и распечатайте полную диагностику: сообщение, сообщение InnerException, все записи Data

Проверочные ключи

config["timeout"] = "30";
config["retries"] = "тридцать";

GetInt(config, "timeout") — 30
GetInt(config, "missing") — InvalidOperationException, Data["ConfigKey"] == "missing"
GetInt(config, "retries") — InvalidOperationException, Data["RawValue"] == "тридцать"

У обоих исключений заполнен InnerException: KeyNotFoundException и FormatException соответственно.
