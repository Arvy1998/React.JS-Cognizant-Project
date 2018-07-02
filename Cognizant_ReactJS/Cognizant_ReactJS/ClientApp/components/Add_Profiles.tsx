import * as React from 'react';
import { RouteComponentProps } from 'react-router';

interface Profile {
    id: number;
    name: string;
    surname: string;
    age: number;
}

interface ProfileState {
    profiles: Profile[];
    loading: boolean;
}

export class Add_Profiles extends React.Component<RouteComponentProps<{}>, ProfileState> {
    constructor() {
        super();

        this.state = { loading: true, profiles: [] };

        fetch('api/profile')
            .then(response => response.json() as Promise<Profile[]>)
            .then(data => {
                this.setState({ profiles: data, loading: false });
                console.log(data);
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p>Loading...</p>
            : AddProfile(this.state.profiles);
        return <div>
            <h1>Add a new profile here: </h1>
            {contents}
        </div>;
    }
}

const AddProfile = (profiles: Profile[]) => {
    return <button /*  onClick={() => { this.Add(profile) } */ type='button'>
            Add New Profile
        </button>
}