import { makeObservable, observable } from 'mobx';

export default class JobPositionStore {
  title = 'Hello from MobX!';

  constructor() {
    makeObservable(this, {
      title: observable,
    });
  }
}
