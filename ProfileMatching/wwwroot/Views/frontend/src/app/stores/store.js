"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.useStore = exports.StoreContext = exports.store = void 0;
const react_1 = require("react");
const jobPositionStore_1 = __importDefault(require("./jobPositionStore"));
exports.store = {
    jobPositionStore: new jobPositionStore_1.default(),
};
exports.StoreContext = react_1.createContext(exports.store);
function useStore() {
    return react_1.useContext(exports.StoreContext);
}
exports.useStore = useStore;
