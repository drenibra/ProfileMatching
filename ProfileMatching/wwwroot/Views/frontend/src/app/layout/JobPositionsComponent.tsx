import { useEffect, useState } from 'react';
import { JobPosition } from '../models/JobPosition';
import { useStore } from '../stores/store';
import JobPositionsList from '../../features/jobPositions/dashboard/JobPositionsList';
import agent from '../api/agent';
import LoadingComponent from './LoadingComponent';
//import {Directory} from '../../../wwwroot/assets/images/';

export default function JobPositionsComponent() {
  const [jobPositions, setJobPositions] = useState<JobPosition[]>([]);
  const [loading, setLoading] = useState(true);

  const { jobPositionStore } = useStore();
  /*   const [isPending, setIsPending] = useState(true);
  const [error, setError] = useState(null);
 */
  useEffect(() => {
    agent.JobPositions.list().then((response) => {
      console.log(response);
      setJobPositions(response);
      setLoading(false);
    });
  }, []);

  var path = 'images/';
  if (loading) return <LoadingComponent open={true} />;
  return <JobPositionsList jobPositions={jobPositions} />;
}
