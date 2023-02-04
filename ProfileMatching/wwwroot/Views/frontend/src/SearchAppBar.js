"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const jsx_runtime_1 = require("react/jsx-runtime");
const styles_1 = require("@mui/material/styles");
const AppBar_1 = __importDefault(require("@mui/material/AppBar"));
const Box_1 = __importDefault(require("@mui/material/Box"));
const Toolbar_1 = __importDefault(require("@mui/material/Toolbar"));
const IconButton_1 = __importDefault(require("@mui/material/IconButton"));
const Typography_1 = __importDefault(require("@mui/material/Typography"));
const InputBase_1 = __importDefault(require("@mui/material/InputBase"));
//import MenuIcon from '@mui/icons-material/Menu';
//import SearchIcon from '@mui/icons-material/Search';
const Search = styles_1.styled('div')(({ theme }) => ({
    position: 'relative',
    borderRadius: theme.shape.borderRadius,
    backgroundColor: styles_1.alpha(theme.palette.common.white, 0.15),
    '&:hover': {
        backgroundColor: styles_1.alpha(theme.palette.common.white, 0.25),
    },
    marginLeft: 0,
    width: '100%',
    [theme.breakpoints.up('sm')]: {
        marginLeft: theme.spacing(1),
        width: 'auto',
    },
}));
const SearchIconWrapper = styles_1.styled('div')(({ theme }) => ({
    padding: theme.spacing(0, 2),
    height: '100%',
    position: 'absolute',
    pointerEvents: 'none',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
}));
const StyledInputBase = styles_1.styled(InputBase_1.default)(({ theme }) => ({
    color: 'inherit',
    '& .MuiInputBase-input': {
        padding: theme.spacing(1, 1, 1, 0),
        // vertical padding + font size from searchIcon
        paddingLeft: `calc(1em + ${theme.spacing(4)})`,
        transition: theme.transitions.create('width'),
        width: '100%',
        [theme.breakpoints.up('sm')]: {
            width: '12ch',
            '&:focus': {
                width: '20ch',
            },
        },
    },
}));
function SearchAppBar() {
    return (jsx_runtime_1.jsx(Box_1.default, Object.assign({ sx: { flexGrow: 1 } }, { children: jsx_runtime_1.jsx(AppBar_1.default, Object.assign({ position: "static" }, { children: jsx_runtime_1.jsxs(Toolbar_1.default, { children: [jsx_runtime_1.jsx(IconButton_1.default, { size: "large", edge: "start", color: "inherit", "aria-label": "open drawer", sx: { mr: 2 } }, void 0), jsx_runtime_1.jsx(Typography_1.default, Object.assign({ variant: "h6", noWrap: true, component: "div", sx: { flexGrow: 1, display: { xs: 'none', sm: 'block' } } }, { children: "GjejPun\u00EB" }), void 0), jsx_runtime_1.jsxs(Search, { children: [jsx_runtime_1.jsx(SearchIconWrapper, {}, void 0), jsx_runtime_1.jsx(StyledInputBase, { placeholder: "Search\u2026", inputProps: { 'aria-label': 'search' } }, void 0)] }, void 0)] }, void 0) }), void 0) }), void 0));
}
exports.default = SearchAppBar;
