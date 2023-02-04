"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const jsx_runtime_1 = require("react/jsx-runtime");
const material_1 = require("@mui/material");
const JobPositionCard_1 = __importDefault(require("./JobPositionCard"));
function JobPositionsList(props) {
    return (jsx_runtime_1.jsx(material_1.Container, { children: jsx_runtime_1.jsx(material_1.Grid, Object.assign({ container: true, spacing: 12 }, { children: props.jobPositions.map((item) => {
                return (jsx_runtime_1.jsx(JobPositionCard_1.default, { id: item.id, title: item.title, description: item.description, skillSet: item.skillSet, createdAt: item.createdAt, expiryDate: item.expiryDate, companyId: item.companyId, category: item.category }, void 0));
            }) }), void 0) }, void 0));
}
exports.default = JobPositionsList;
