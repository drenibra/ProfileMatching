import { Alert, Card, CardContent, Container, Grid, Typography } from '@mui/material';
import { observer } from 'mobx-react-lite';
import { useEffect, useState } from 'react';
import agent from '../api/agent';
import { ApplicationsByApplicant } from '../models/ApplicationsByApplicant';
import { useStore } from '../stores/store';
import LoadingComponent from './LoadingComponent';

export default observer(function MyApplications() {
  const [applications, setApplications] = useState<ApplicationsByApplicant[]>([]);
  const { userStore } = useStore();
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    (async () => {
      const userId = await userStore.getCurrentUserId();
      const response = await agent.Application.listByApplicant(userId);
      setApplications(response);
      setLoading(false);
      console.log(response);
    })();
  }, []);

  if (loading) return <LoadingComponent open={true} />;

  return !userStore.isApplicant ? (
    <Alert severity="error">You aren't an applicant</Alert>
  ) : (
    <Container>
      <Grid container sx={{ mt: 3 }} spacing={3}>
        {applications.length > 0 ? (
          applications.map((app) => {
            return (
              <Grid item xs={6}>
                <Card>
                  <CardContent>
                    <Typography variant="h6">{app.jobPosition.title}</Typography>
                    <Typography variant="body1">{app.jobPosition.company.name}</Typography>
                    <Typography variant="body2">Applied at: {app.date.toString()}</Typography>
                  </CardContent>
                </Card>
              </Grid>
            );
          })
        ) : (
          <Alert severity="error">You haven't made any applications</Alert>
        )}
      </Grid>
    </Container>
  );
});
