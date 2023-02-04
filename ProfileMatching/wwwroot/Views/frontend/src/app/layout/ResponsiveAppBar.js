"use strict";
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    Object.defineProperty(o, k2, { enumerable: true, get: function() { return m[k]; } });
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || function (mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (k !== "default" && Object.prototype.hasOwnProperty.call(mod, k)) __createBinding(result, mod, k);
    __setModuleDefault(result, mod);
    return result;
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const jsx_runtime_1 = require("react/jsx-runtime");
const React = __importStar(require("react"));
const AppBar_1 = __importDefault(require("@mui/material/AppBar"));
const Box_1 = __importDefault(require("@mui/material/Box"));
const Toolbar_1 = __importDefault(require("@mui/material/Toolbar"));
const IconButton_1 = __importDefault(require("@mui/material/IconButton"));
const Typography_1 = __importDefault(require("@mui/material/Typography"));
const Menu_1 = __importDefault(require("@mui/material/Menu"));
const Menu_2 = __importDefault(require("@mui/icons-material/Menu"));
const Container_1 = __importDefault(require("@mui/material/Container"));
const Avatar_1 = __importDefault(require("@mui/material/Avatar"));
const Button_1 = __importDefault(require("@mui/material/Button"));
const Tooltip_1 = __importDefault(require("@mui/material/Tooltip"));
const MenuItem_1 = __importDefault(require("@mui/material/MenuItem"));
const Adb_1 = __importDefault(require("@mui/icons-material/Adb"));
const pages = ['Job Positions', 'Companies', 'About Us'];
const settings = ['Profile', 'Account', 'Dashboard', 'Logout'];
function ResponsiveAppBar() {
    const [anchorElNav, setAnchorElNav] = React.useState(null);
    const [anchorElUser, setAnchorElUser] = React.useState(null);
    const handleOpenNavMenu = (event) => {
        setAnchorElNav(event.currentTarget);
    };
    const handleOpenUserMenu = (event) => {
        setAnchorElUser(event.currentTarget);
    };
    const handleCloseNavMenu = () => {
        setAnchorElNav(null);
    };
    const handleCloseUserMenu = () => {
        setAnchorElUser(null);
    };
    return (jsx_runtime_1.jsx(AppBar_1.default, Object.assign({ position: "static" }, { children: jsx_runtime_1.jsx(Container_1.default, Object.assign({ maxWidth: "xl" }, { children: jsx_runtime_1.jsxs(Toolbar_1.default, Object.assign({ disableGutters: true }, { children: [jsx_runtime_1.jsx(Typography_1.default, Object.assign({ variant: "h6", noWrap: true, component: "a", href: "/", sx: {
                            mr: 2,
                            display: { xs: 'none', md: 'flex' },
                            fontFamily: 'monospace',
                            fontWeight: 700,
                            letterSpacing: '.3rem',
                            color: 'inherit',
                            textDecoration: 'none',
                        } }, { children: "GjejPune" }), void 0), jsx_runtime_1.jsxs(Box_1.default, Object.assign({ sx: { flexGrow: 1, display: { xs: 'flex', md: 'none' } } }, { children: [jsx_runtime_1.jsx(IconButton_1.default, Object.assign({ size: "large", "aria-label": "account of current user", "aria-controls": "menu-appbar", "aria-haspopup": "true", onClick: handleOpenNavMenu, color: "inherit" }, { children: jsx_runtime_1.jsx(Menu_2.default, {}, void 0) }), void 0), jsx_runtime_1.jsx(Menu_1.default, Object.assign({ id: "menu-appbar", anchorEl: anchorElNav, anchorOrigin: {
                                    vertical: 'bottom',
                                    horizontal: 'left',
                                }, keepMounted: true, transformOrigin: {
                                    vertical: 'top',
                                    horizontal: 'left',
                                }, open: Boolean(anchorElNav), onClose: handleCloseNavMenu, sx: {
                                    display: { xs: 'block', md: 'none' },
                                } }, { children: pages.map((page) => (jsx_runtime_1.jsx(MenuItem_1.default, Object.assign({ onClick: handleCloseNavMenu }, { children: jsx_runtime_1.jsx(Typography_1.default, Object.assign({ textAlign: "center" }, { children: page }), void 0) }), page))) }), void 0)] }), void 0), jsx_runtime_1.jsx(Adb_1.default, { sx: { display: { xs: 'flex', md: 'none' }, mr: 1 } }, void 0), jsx_runtime_1.jsx(Typography_1.default, Object.assign({ variant: "h5", noWrap: true, component: "a", href: "", sx: {
                            mr: 2,
                            display: { xs: 'flex', md: 'none' },
                            flexGrow: 1,
                            fontFamily: 'monospace',
                            fontWeight: 700,
                            letterSpacing: '.3rem',
                            color: 'inherit',
                            textDecoration: 'none',
                        } }, { children: "LOGO" }), void 0), jsx_runtime_1.jsx(Box_1.default, Object.assign({ sx: { flexGrow: 1, display: { xs: 'none', md: 'flex' } } }, { children: pages.map((page) => (jsx_runtime_1.jsx(Button_1.default, Object.assign({ onClick: handleCloseNavMenu, sx: { my: 2, color: 'white', display: 'block' } }, { children: page }), page))) }), void 0), jsx_runtime_1.jsxs(Box_1.default, Object.assign({ sx: { flexGrow: 0 } }, { children: [jsx_runtime_1.jsx(Tooltip_1.default, Object.assign({ title: "Open settings" }, { children: jsx_runtime_1.jsx(IconButton_1.default, Object.assign({ onClick: handleOpenUserMenu, sx: { p: 0 } }, { children: jsx_runtime_1.jsx(Avatar_1.default, { alt: "Remy Sharp", src: "/static/images/avatar/2.jpg" }, void 0) }), void 0) }), void 0), jsx_runtime_1.jsx(Menu_1.default, Object.assign({ sx: { mt: '45px' }, id: "menu-appbar", anchorEl: anchorElUser, anchorOrigin: {
                                    vertical: 'top',
                                    horizontal: 'right',
                                }, keepMounted: true, transformOrigin: {
                                    vertical: 'top',
                                    horizontal: 'right',
                                }, open: Boolean(anchorElUser), onClose: handleCloseUserMenu }, { children: settings.map((setting) => (jsx_runtime_1.jsx(MenuItem_1.default, Object.assign({ onClick: handleCloseUserMenu }, { children: jsx_runtime_1.jsx(Typography_1.default, Object.assign({ textAlign: "center" }, { children: setting }), void 0) }), setting))) }), void 0)] }), void 0)] }), void 0) }), void 0) }), void 0));
}
exports.default = ResponsiveAppBar;
