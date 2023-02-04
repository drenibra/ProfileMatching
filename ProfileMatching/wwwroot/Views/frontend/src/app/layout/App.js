"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const jsx_runtime_1 = require("react/jsx-runtime");
const ResponsiveAppBar_1 = __importDefault(require("./ResponsiveAppBar"));
const system_1 = require("@mui/system");
const JobPositionsComponent_1 = __importDefault(require("./JobPositionsComponent"));
const JobPositionDetails_1 = __importDefault(require("../../features/jobPositions/details/JobPositionDetails"));
const JobPositionForm_1 = __importDefault(require("../../features/jobPositions/form/JobPositionForm"));
const logo = require('./../../logo.svg');
function App() {
    return (jsx_runtime_1.jsxs("div", Object.assign({ className: "App" }, { children: [jsx_runtime_1.jsx(ResponsiveAppBar_1.default, {}, void 0), jsx_runtime_1.jsx(system_1.Box, { mt: 13 }, void 0), jsx_runtime_1.jsx(JobPositionsComponent_1.default, {}, void 0), jsx_runtime_1.jsx(JobPositionDetails_1.default, {}, void 0), jsx_runtime_1.jsx(JobPositionForm_1.default, {}, void 0)] }), void 0));
}
exports.default = App;
