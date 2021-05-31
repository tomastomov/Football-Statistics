import { Component } from "react";
import { Form } from 'react-bootstrap'

export class LeaguesSelectList extends Component {
    render() {
        return (
            <Form onChange={this.props.leagueChangedHandler}>
                <Form.Label>League    </Form.Label>
                <Form.Control as="select" custom>
                    {this.props.leagues.map(league => (
                        <option key={league.id} value={league.id}>{league.name}</option>
                    ))}
                </Form.Control>
            </Form>
            // <div>
            //     <select onChange={this.props.leagueChangedHandler}> 
            //         {this.props.leagues.map(league => (
            //             <option key={league.id} value={league.id}>{league.name}</option>
            //         ))}
            //     </select>
            // </div>
        )
    }
}