namespace Entitas {
    public partial class Entity {
        public PersonComponent person { get { return (PersonComponent)GetComponent(ComponentIds.Person); } }

        public bool hasPerson { get { return HasComponent(ComponentIds.Person); } }

        public Entity AddPerson(int newAge, string newName) {
            var componentPool = GetComponentPool(ComponentIds.Person);
            var component = (PersonComponent)(componentPool.Count > 0 ? componentPool.Pop() : new PersonComponent());
            component.age = newAge;
            component.name = newName;
            return AddComponent(ComponentIds.Person, component);
        }

        public Entity ReplacePerson(int newAge, string newName) {
            var componentPool = GetComponentPool(ComponentIds.Person);
            var component = (PersonComponent)(componentPool.Count > 0 ? componentPool.Pop() : new PersonComponent());
            component.age = newAge;
            component.name = newName;
            ReplaceComponent(ComponentIds.Person, component);
            return this;
        }

        public Entity RemovePerson() {
            return RemoveComponent(ComponentIds.Person);;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherPerson;

        public static IMatcher Person {
            get {
                if (_matcherPerson == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Person);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherPerson = matcher;
                }

                return _matcherPerson;
            }
        }
    }
}
