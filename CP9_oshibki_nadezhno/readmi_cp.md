<img width="1165" height="537" alt="image" src="https://github.com/user-attachments/assets/d36661dc-47de-4c44-bb88-2846726e73ca" />

<img width="1432" height="397" alt="image" src="https://github.com/user-attachments/assets/aeedfdd1-114c-46f8-89f6-86af3a8783c5" />

Проверочные ключи

На входе ["ORDER001;150,50;3", "плохая строка", "ORDER002;-10;1", "ORDER003;200;2"]:

ORDER001;150,50;3 — обработан успешно
плохая строка — пропущен, предупреждение о формате, без исключения
ORDER002;-10;1 — OrderProcessingException, пойман через when, пропущен
ORDER003;200;2 — обработан успешно
итог — обработано 4, успешно 2, пропущено 2
