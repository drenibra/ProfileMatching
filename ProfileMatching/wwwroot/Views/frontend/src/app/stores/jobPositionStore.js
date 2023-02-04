"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const mobx_1 = require("mobx");
class JobPositionStore {
    constructor() {
        this.title = 'Hello from MobX!';
        mobx_1.makeObservable(this, {
            title: mobx_1.observable,
        });
    }
}
exports.default = JobPositionStore;
