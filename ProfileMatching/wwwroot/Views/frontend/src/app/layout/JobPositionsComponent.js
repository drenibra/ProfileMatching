"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const jsx_runtime_1 = require("react/jsx-runtime");
const react_1 = require("react");
const axios_1 = __importDefault(require("axios"));
const store_1 = require("../stores/store");
const JobPositionsList_1 = __importDefault(require("../../features/jobPositions/dashboard/JobPositionsList"));
//import {Directory} from '../../../wwwroot/assets/images/';
function JobPositionsComponent() {
    const [jobPositions, setJobPositions] = react_1.useState([]);
    const { jobPositionStore } = store_1.useStore();
    /*   const [isPending, setIsPending] = useState(true);
    const [error, setError] = useState(null);
   */
    react_1.useEffect(() => {
        axios_1.default
            .get('http://localhost:5048/api/v1/jobposition')
            .then((response) => {
            setJobPositions(response.data);
        });
    }, []);
    var path = 'images/';
    return jsx_runtime_1.jsx(JobPositionsList_1.default, { jobPositions: jobPositions }, void 0);
}
exports.default = JobPositionsComponent;
