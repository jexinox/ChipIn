<b>Название проекта:</b> Скинемся!

<b>Команда:</b> АТ-04

<b>Формат системы:</b> 
Мобильное веб-приложение

<b>Цель проекта:</b>  

Облегчить расчёт суммы долга с человека при совместных покупках для вечеринок

<b>Описание:</b>  
Сервис собирает информацию о гостях, закупках, предлагает каждому гостю выбрать то, что нужно ему. И на основе этих данных рассчитывает сумму долга для каждого гостя,
помимо прочего, помогая контролировать возврат

<b>Целевая аудитория:</b>  
Молодые люди из СНГ, пользователи ВКонтакте

<b>Основное преимущество:</b>  
Отсутствие подобных решений на рынке, удобство и минимальные затраты времени на проведение расчёта.

<b>Стек технологий:</b> 
C#. ASP.NET Core & MVC, MongoDB

<b>Сценарий использования:</b>  
1. Администратор создает комнату, заполняет товары и цены, устанавливает дату окончания выбора продуктов
2. Администратор приглашает гостей в комнату
3. Гости выбирают интересующие их товары. Если они не находят нужного им продукта, они могут создать свой сбор, к которому так же могут подключиться другие гости
4. Во время наступления установленного времени, возможность выбора продуктов закрывается и высвечивается окно суммы долга для каждого пользователя

<b>Результат / продукт:</b> 
Веб-приложение в среде VK Mini Apps, осуществляющее функции расчёта стоимости продуктов

<b>Структура приложения:</b> <br>
Контроллеры - src/ChipIn/Controllers<br>
Модели - src/ChipIn/Models<br>
Сервисы - src/ChipIn/Services
