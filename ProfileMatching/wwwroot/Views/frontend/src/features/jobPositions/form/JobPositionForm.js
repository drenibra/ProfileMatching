"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const jsx_runtime_1 = require("react/jsx-runtime");
const material_1 = require("@mui/material");
const DesktopDatePicker_1 = require("@mui/x-date-pickers/DesktopDatePicker");
const Textarea_1 = __importDefault(require("@mui/joy/Textarea"));
const react_1 = require("react");
const x_date_pickers_1 = require("@mui/x-date-pickers");
const AdapterDayjs_1 = require("@mui/x-date-pickers/AdapterDayjs");
const dayjs_1 = __importDefault(require("dayjs"));
function JobPositonForm() {
    const [value, setValue] = react_1.useState(dayjs_1.default());
    const handleChange = (newValue) => {
        setValue(newValue);
    };
    return (jsx_runtime_1.jsx(material_1.Container, Object.assign({ sx: {
            width: 600,
        } }, { children: jsx_runtime_1.jsxs(material_1.Stack, Object.assign({ spacing: 2 }, { children: [jsx_runtime_1.jsx(material_1.Typography, Object.assign({ variant: "h5", sx: { mb: 3 } }, { children: "Create a job position" }), void 0), jsx_runtime_1.jsxs(material_1.FormControl, Object.assign({ sx: { mb: 3 } }, { children: [jsx_runtime_1.jsx(material_1.InputLabel, Object.assign({ htmlFor: "title" }, { children: "Title" }), void 0), jsx_runtime_1.jsx(material_1.Input, { id: "title", "aria-describedby": "job title" }, void 0)] }), void 0), jsx_runtime_1.jsxs(material_1.FormControl, Object.assign({ sx: { mb: 3 } }, { children: [jsx_runtime_1.jsx(material_1.InputLabel, Object.assign({ htmlFor: "description" }, { children: "Description" }), void 0), jsx_runtime_1.jsx(material_1.Input, { id: "description", "aria-describedby": "job description" }, void 0)] }), void 0), jsx_runtime_1.jsx(material_1.FormControl, Object.assign({ sx: { mb: 3 } }, { children: jsx_runtime_1.jsx(Textarea_1.default, { minRows: 4, placeholder: "Job description...", variant: "outlined" }, void 0) }), void 0), jsx_runtime_1.jsxs(material_1.FormControl, Object.assign({ sx: { mb: 3 } }, { children: [jsx_runtime_1.jsx(material_1.InputLabel, Object.assign({ htmlFor: "skills" }, { children: "Skills" }), void 0), jsx_runtime_1.jsx(material_1.Input, { id: "skills", "aria-describedby": "skills" }, void 0)] }), void 0), jsx_runtime_1.jsx(x_date_pickers_1.LocalizationProvider, Object.assign({ dateAdapter: AdapterDayjs_1.AdapterDayjs, sx: { mt: 3 } }, { children: jsx_runtime_1.jsx(DesktopDatePicker_1.DesktopDatePicker, { label: "Expiration Date", inputFormat: "MM/DD/YYYY", value: value, onChange: handleChange, renderInput: (params) => jsx_runtime_1.jsx(material_1.TextField, Object.assign({}, params), void 0) }, void 0) }), void 0), jsx_runtime_1.jsxs(material_1.FormControl, Object.assign({ sx: { mt: 3 } }, { children: [jsx_runtime_1.jsx(material_1.InputLabel, Object.assign({ htmlFor: "company" }, { children: "Company Id" }), void 0), jsx_runtime_1.jsx(material_1.Input, { id: "company", "aria-describedby": "company" }, void 0)] }), void 0), jsx_runtime_1.jsxs(material_1.FormControl, Object.assign({ sx: { mt: 3 } }, { children: [jsx_runtime_1.jsx(material_1.InputLabel, Object.assign({ htmlFor: "category" }, { children: "Category" }), void 0), jsx_runtime_1.jsx(material_1.Input, { id: "category", "aria-describedby": "category" }, void 0)] }), void 0), jsx_runtime_1.jsxs(material_1.Grid, Object.assign({ container: true }, { children: [jsx_runtime_1.jsx(material_1.Grid, Object.assign({ item: true, xs: 6 }, { children: jsx_runtime_1.jsx(material_1.Button, Object.assign({ sx: { width: '94%', mr: 2 }, variant: "contained" }, { children: "Open Job Position" }), void 0) }), void 0), jsx_runtime_1.jsx(material_1.Grid, Object.assign({ item: true, xs: 6 }, { children: jsx_runtime_1.jsx(material_1.Button, Object.assign({ sx: { width: '94%', ml: 2 }, variant: "outlined" }, { children: "Cancel" }), void 0) }), void 0)] }), void 0)] }), void 0) }), void 0));
}
exports.default = JobPositonForm;
