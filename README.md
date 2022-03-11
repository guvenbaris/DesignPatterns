# Design Patterns 
Tasarım kalıpları, yazılım geliştiricilerin yazılım geliştirme sırasında karşılaştıkları 
genel sorunların çözümüdür. 

Bu repository de  tasarım kalıpları örnek code'lar ile açıklanmıştır. 

**Tasarım kalıpları** 

* Abstract Factory      
* Adapter
* Bridge
* Builder
* Chain Of Resposibilty
* Command 
* Composite
* Decorator
* DependencyInjection
* Facade
* FactoryMethod
* Mediator
* Momento
* Multiton
* NullObject
* Observer
* Prototype
* Proxy
* Singleton
* State
* Strategy
* TemplateMethod
* Visitor

Bunlardan bir kaç tanesini açıklamak gerekirse 

# Dependency Injection
Bağımlılık oluşturacak nesneleri direkt olarak kullanmak yerine, 
bu nesneleri dışardan verilmesiyle sistem içerisindeki bağımlılığı minimize etmek amaçlanır.
Böylece bağımlılık bulunan sınıf üzerindeki değişikliklerden korunmuş oluruz.

Unit testlerin yazımını kolaylaştırırken doğruluğunu da artırır. 
Yazılım geliştirmedeki en önemli konulardan biri de yazılım içerisinde bulunan componentlerin
“loosely coupled” (gevşek bağlı) olmasıdır. Dependency Injection’da bunu sağlayabilen önemli
 tekniklerden birisidir. Böylece bağımsızlığı sağlanan sınıflar tek başına test edilebilir.

 # Factory Design Pattern
 Kelime anlamı “Fabrika Metodu” olan Factory Method, üst sınıfta nesneler oluşturmak için bir arabirim sağlayan, 
 ancak alt sınıfların oluşturulacak bu nesne türünü değiştirmesine izin veren bir yaratımsal desen (creational pattern) türüdür.

 # Strategy Design Pattern 
 Strategy Pattern aynı işi yapacak birden çok strategy'iniz var ise bunu en iyi şekilde programınıza aktarmanızı sağlar. 
 Bunun için bir Strategy interface'i oluştururuz.Tüm strategy'ler bu interface'den türetilir ve client bu interface'i kullanarak tüm strategy'lere  ulaşabilir.
