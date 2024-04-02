# [Лабораторна робота №2](https://learn.ztu.edu.ua/mod/assign/view.php?id=199396)

## Породжувальні шаблони.

**Мета:** навчитися реалізовувати породжувальні шаблони проєктування.


TODO:
- [x] [Завдання 0](#user-content-завдання-0)
- [ ] [Завдання 1](#user-content-завдання-1)
- [ ] [Завдання 2](#user-content-завдання-2)
- [ ] [Завдання 3](#user-content-завдання-3)
- [ ] [Завдання 4](#user-content-завдання-4)
- [ ] [Завдання 5](#user-content-завдання-5)

---

## Завдання 0

Створення репозиторію.

## [Завдання 1](FactoryLibrary)

Фабричний метод.

1. Напишіть систему класів для реалізації функціоналу
   створення різних типів підписок для відео провайдера.
2. Кожна з підписок повинна мати щомісячну плату, мінімальний
   період підписки та список каналів й інших можливостей.
3. Види підписок: `DomesticSubscription`,
   `EducationalSubscription`, `PremiumSubscription`.
4. Придбати (тобто створити) підписку можна за допомогою
   трьох різних класів: `WebSite`, `MobileApp`, `ManagerCall`, кожен з них
   має реалізувати свою логіку створення підписок.
5. Покажіть правильність роботи свого коду запустивши його в
   [головному методі програми](ConsoleApp/Program.cs).
6. Підготуйте діаграму створених у програмі класів та
   інтерфейсів за допомогою https://app.diagrams.net/, експортуйте та
   завантажте її до репозиторія.

## [Завдання 2](AbstractFactoryLibrary)

Абстрактна фабрика.

1. Створіть фабрику виробництва техніки.
2. На фабриці мають створюватися різні девайси (наприклад,
   Laptop, Netbook, EBook, Smartphone) для різних брендів (IProne,
   Kiaomi, Balaxy).
3. Покажіть правильність роботи свого коду запустивши його в
   [головному методі програми](ConsoleApp/Program.cs).
4. Підготуйте діаграму створених у програмі класів та інтерфейсів за
   допомогою https://app.diagrams.net/, експортуйте та завантажте її
   до репозиторія.

## [Завдання 3](SingletonLibrary)

Одинак.

1. Створіть клас `Authenticator` таким чином, щоб бути
   впевненим, що цей клас може створити лише один екземпляр,
   незалежно від кількості потоків і класів, що його наслідують.
2. Покажіть правильність роботи свого коду запустивши його в
   [головному методі програми](ConsoleApp/Program.cs).

## [Завдання 4](PrototypeLibrary)

Прототип

1. Створіть клас `Virus`. Він повинен містити вагу, вік, ім’я, вид і
   масив дітей, екземплярів `Virus`.
2. Створіть екземпляри для цілого “сімейства” вірусів (мінімум
   три покоління).
3. За допомогою шаблону Прототип реалізуйте можливість
   клонування наявних вірусів.
4. При клонуванні віруса-батька повинні клонуватися всі його
   діти.
5. Покажіть правильність роботи свого коду запустивши його в
   [головному методі програми](ConsoleApp/Program.cs).

## [Завдання 5](BuilderLibrary)

Будівельник.

1. Створіть клас `HeroBuilder`, який буде створювати персонажа
   гри, поступово додаючи до нього різні ознаки, наприклад зріст,
   статуру, колір волосся, очей, одяг, інвентар тощо (можете включити
   фантазію).
2. Створіть клас `EnemyBuilder`, який буде реалізовувати єдиний
   інтерфейс з `HeroBuilder`. Відмінністю між ними можуть бути
   спеціальні методи для творення добра або зла, а також списки
   добрих і злих справ відповідно.
3. За допомогою свого білдера і класу-директора створіть героя
   (або героїню) своєї мрії 🙂, а також свого найзапеклішого ворога.
4. Зверніть увагу, що Ваші білдери повинні реалізовувати
   текучий интерфейс (fluent interface).
5. Покажіть правильність роботи свого коду запустивши його в
   [головному методі програми](ConsoleApp/Program.cs).
6. Підготуйте діаграму створених у програмі класів та
   інтерфейсів за допомогою https://app.diagrams.net/, експортуйте та
   завантажте її до репозиторія.
