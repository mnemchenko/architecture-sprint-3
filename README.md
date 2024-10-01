# Архитектура

## As Is

### Функциональность приложения

#### Управление отоплением:
- Пользователи могут удалённо включать/выключать отопление в своих домах.
- Пользователи могут устанавливать желаемую температуру.
- Система автоматически поддерживает заданную температуру, регулируя подачу тепла.

#### Мониторинг температуры:
- Система получает данные о температуре с датчиков, установленных в домах.
- Пользователи могут просматривать текущую температуру в своих

### Общее описание архитектуры

- Язык программирования: Java
- База данных: PostgreSQL
- Архитектура: Монолитная, все компоненты системы (обработка запросов, бизнес-логика, работа с данными) находятся в рамках одного приложения.
- Взаимодействие: Синхронное, запросы обрабатываются последовательно. Всё управление идёт от сервера к датчику. Данные о температуре также получаются через запрос от сервера к датчику.
- Масштабируемость: Ограничена, так как монолит сложно масштабировать по частям.
- Развертывание: Требует остановки всего приложения.

#### Сильные стороны
- **Простота разработки и отладки.** Весь код приложения находится в одном репозитории, что упрощает понимание общей структуры, навигацию и работу с кодом. Отладка монолита легче, так как все части системы запускаются из одного проекта.
- **Быстрая разработка и внедрение на ранних этапах.** Нет необходимости управлять коммуникацией между сервисами и сложной инфраструктурой. Можно быстрее разрабатывать и развертывать новую функциональность без необходимости настройки межсервисных взаимодействий.
- **Целостность данных.** Данные обычно хранятся в одной базе данных, что устраняет необходимость решать проблемы с распределённой транзакционностью и консистентностью данных.
- **Простота тестирования.** Монолит легче тестировать, так как все компоненты находятся в одном приложении. Не требуется развертывание отдельных сервисов и координация их взаимодействий для проведения интеграционных тестов.
- **Меньшие операционные затраты** Развертывание монолитного приложения проще, так как не требуется сложной оркестрации микросервисов. Меньшее количество сервисов означает меньшее количество инфраструктурных решений для мониторинга, логирования и управления.

#### Слабые стороны
- **Высокий риск ошибок.** Изменения в одной части приложения могут непредсказуемо влиять на другие части. Из-за этого вырастает вероятность возникновения ошибок и компании приходится тратить дополнительные ресурсы на тестирование.
- **Длительные циклы разработки и развёртывания.** При каждом изменении приходится тестировать всё приложение целиком. Это замедляет выпуск новых функций.
- **Трудно управлять командой.** В больших командах работа над монолитом часто приводит к конфликтам и задержкам. Изменения, которые вносит одна команда, влияют на работу других команд. Учитывая конечное состояние, в которое система должна быть приведена, команду точно придется увеличивать и этот фактор будет сильно влиять.
- **Трудно масштабировать отдельные компоненты системы.** С монолитной архитектурой не получится масштабировать только одну часть системы — придётся масштабировать приложение целиком.
- **Синхронное взаимодействие плохо масштабируется на нагрузке.** Получается, что нагрузка управляет нами, а не мы ей. Нагрузка определяет, сколько ресурсов должно использоваться в определенный момент времени. Тогда как, при отложенной обработке, пороки использования ресурсов определяем мы сами (планируя, сколько потратить на консьюмеры).
- **Реляционная БД тяжелее шардируется.** Нужно устанавливать и поддерживать отдельное решение для управления шардированием.
- **Единая точка отказа.** Отказа одной части приложения с высокой степенью вероятности влечет отказ всего приложения сразу

### Домены и границы контекстов

#### As Is

Домены:

- Управление пользователями
  - Контекст: Управление пользователями
- Управление инфраструктурой
  - Контекст: Управление устройствами, Мониторинг статуса устройств
- Управление климатом
  - Контекст: Управление температурой
- Телеметрия
  - Контекст: Мониторинг показателей: температуры, режима работы отопления и тп

#### To Be

- Управление пользователями
  - Контекст: Управление пользователями
- Управление инфраструктурой
  - Контекст: Управления размещением (поселки, дома, прикрепление пользователей к домам)
  - Контекст: Управление устройствами, Мониторинг статуса устройств
- Управление климатом
  - Контекст: Управление температурой
- Управление освещением
  - Контекст: Управление освещением
- Управление доступом
  - Контекст: Управление доступом
- Наблюдение
  - Контекст: Управление наблюдением
- Телеметрия
  - Контекст: Мониторинг показателей: температуры, режима работы отопления, режима работы освещения и тп
- Аудит
  - Контекст: Проведение аудита истории управляющих событий

# Базовая настройка

## Запуск minikube

[Инструкция по установке](https://minikube.sigs.k8s.io/docs/start/)

```bash
minikube start
```


## Добавление токена авторизации GitHub

[Получение токена](https://github.com/settings/tokens/new)

```bash
kubectl create secret docker-registry ghcr --docker-server=https://ghcr.io --docker-username=<github_username> --docker-password=<github_token> -n default
```


## Установка API GW kusk

[Install Kusk CLI](https://docs.kusk.io/getting-started/install-kusk-cli)

```bash
kusk cluster install
```


## Настройка terraform

[Установите Terraform](https://yandex.cloud/ru/docs/tutorials/infrastructure-management/terraform-quickstart#install-terraform)


Создайте файл ~/.terraformrc

```hcl
provider_installation {
  network_mirror {
    url = "https://terraform-mirror.yandexcloud.net/"
    include = ["registry.terraform.io/*/*"]
  }
  direct {
    exclude = ["registry.terraform.io/*/*"]
  }
}
```

## Применяем terraform конфигурацию 

```bash
cd terraform
terraform apply
```

## Настройка API GW

```bash
kusk deploy -i api.yaml
```

## Проверяем работоспособность

```bash
kubectl port-forward svc/kusk-gateway-envoy-fleet -n kusk-system 8080:80
curl localhost:8080/hello
```


## Delete minikube

```bash
minikube delete
```
