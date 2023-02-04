"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const jsx_runtime_1 = require("react/jsx-runtime");
const client_1 = __importDefault(require("react-dom/client"));
require("./index.css");
const App_1 = __importDefault(require("./app/layout/App"));
const store_1 = require("./app/stores/store");
const root = client_1.default.createRoot(document.getElementById('root'));
root.render(jsx_runtime_1.jsx(store_1.StoreContext.Provider, Object.assign({ value: store_1.store }, { children: jsx_runtime_1.jsx(App_1.default, {}, void 0) }), void 0));
