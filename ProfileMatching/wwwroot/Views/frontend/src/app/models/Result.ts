import { ApplicationsByApplicant } from './ApplicationsByApplicant';
import { AppUser } from './User';

export interface Result {
  application: ApplicationsByApplicant;
  result: number;
  applicant: AppUser;
}
