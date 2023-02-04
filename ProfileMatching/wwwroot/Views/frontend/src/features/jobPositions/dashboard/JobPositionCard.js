"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const jsx_runtime_1 = require("react/jsx-runtime");
const material_1 = require("@mui/material");
const axios_1 = __importDefault(require("axios"));
const react_1 = require("react");
function JobPositionCard(props) {
    const [editMode, setEditMode] = react_1.useState(false);
    const handeFormOpen = () => {
        setEditMode(true);
    };
    const handeFormClose = () => {
        setEditMode(false);
    };
    const [logo, setLogo] = react_1.useState('');
    const companyLogo = axios_1.default
        .get('http://localhost:5048/api/v1/Company/' + props.companyId)
        .then((res) => {
        console.log(res.data);
        setLogo(res.data.logo);
    });
    return (jsx_runtime_1.jsx(material_1.Grid, Object.assign({ item: true, xs: 4 }, { children: jsx_runtime_1.jsx(material_1.Card, { children: jsx_runtime_1.jsxs(material_1.CardActionArea, { children: [jsx_runtime_1.jsx(material_1.CardMedia, { component: "img", height: "200", image: logo, sx: { objectFit: 'contain' } }, void 0), jsx_runtime_1.jsxs(material_1.CardContent, { children: [jsx_runtime_1.jsx(material_1.Typography, Object.assign({ gutterBottom: true, variant: "h5", component: "div" }, { children: props.title }), void 0), jsx_runtime_1.jsxs(material_1.Typography, Object.assign({ variant: "body2", color: "text.secondary" }, { children: ["Description: ", props.description] }), void 0), jsx_runtime_1.jsxs(material_1.Typography, Object.assign({ variant: "body2", color: "text.secondary" }, { children: ["Requirements: ", props.skillSet] }), void 0), jsx_runtime_1.jsx(material_1.Typography, Object.assign({ variant: "body2", color: "text.secondary" }, { children: jsx_runtime_1.jsxs(jsx_runtime_1.Fragment, { children: ["Skadon m\u00EB: ", props.expiryDate] }, void 0) }), void 0)] }, void 0)] }, void 0) }, props.id) }), void 0));
}
exports.default = JobPositionCard;
