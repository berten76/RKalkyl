import React from 'react';
import { Link } from 'react-router-dom';
import { Button, Header, Icon, Segment } from 'semantic-ui-react';

export default function NotFound() {
    return (
        <Segment placeholder>
            <Header icon>
                <Icon name='search' />
                 Oop culd not found this
            </Header>
            <Segment.Inline>
                <Button as={Link} to='/meals' primary>
                    Return to meal page
                </Button>
            </Segment.Inline>
        </Segment>
    )
}