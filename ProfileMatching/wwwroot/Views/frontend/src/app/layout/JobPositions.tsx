import { Box, Container, Grid } from '@mui/material';
import { useEffect, useState } from 'react';
import agent from '../api/agent';
import { JobPosition } from '../models/JobPosition';
import JobPositionCard from '../../features/jobPositions/dashboard/JobPositionCard';
import LoadingComponent from './LoadingComponent';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';

export default observer(function JobPositionsList() {
  const { userStore } = useStore();
  const [jobPositions, setJobPositions] = useState<JobPosition[]>([]);
  const [loading, setLoading] = useState(true);
  const [applied, setApplied] = useState(false);

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

  const handleApply = async (jobId: number) => {
    try {
      const userId = await userStore.getCurrentUserId();
      const a = await userStore.apply({ jobPositionId: jobId, applicantId: userId });
      console.log(a);
      setApplied(a);
    } catch (error) {
      console.log(error);
    }
  };

  var path = 'images/';
  if (loading) return <LoadingComponent open={true} />;

  return (
    <Container sx={{ mt: 5 }}>
      <Grid container spacing={12}>
        {jobPositions.map((item) => {
          return (
            <JobPositionCard applied={applied} setApplied={setApplied} jobPosition={item} handleApply={handleApply} />
          );
        })}
      </Grid>
    </Container>
  );
});
