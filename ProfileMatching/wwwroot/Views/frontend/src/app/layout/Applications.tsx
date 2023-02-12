import { Alert, Card, CardContent, Grid, Typography } from '@mui/material';
import { observer } from 'mobx-react-lite';
import { useEffect, useState } from 'react';
import agent from '../api/agent';
import { useStore } from '../stores/store';
import { Result } from './../models/Result';

export default observer(function Applications() {
  const [applications, setApplications] = useState<Result[]>([]);
  const { userStore } = useStore();
  useEffect(() => {
    agent.Results.list().then((response) => {
      setApplications(response);
      console.log(response);
    });
  });

  return userStore.isApplicant ? (
    <Alert severity="error">You don't have access!</Alert>
  ) : (
    <Grid container sx={{ mt: 3 }} spacing={3}>
      {applications.length > 0 ? (
        applications.map((app) => {
          return (
            <Grid item xs={6}>
              <Card>
                <CardContent>
                  <Typography variant="h6">{app.application.jobPosition.title}</Typography>
                  {/* <Typography variant="body2">
                    {app.applicant.name} {app.applicant.surname}
                  </Typography> */}
                  <Typography variant="body2">{app.result}% Match</Typography>
                </CardContent>
              </Card>
            </Grid>
          );
        })
      ) : (
        <Alert severity="error">There are no applications!</Alert>
      )}
    </Grid>
  );
});
